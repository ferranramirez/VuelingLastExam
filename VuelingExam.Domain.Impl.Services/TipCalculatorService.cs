using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Impl.Services.Exceptions;
using VuelingExam.Domain.Impl.Services.Resources;

namespace VuelingExam.Domain.Impl.Services
{
    public class TipCalculatorService : ITipCalculatorService
    {
        ILogger Log;
        public TipCalculatorService(ILogger logger)
        {
            Adj = new Dictionary<string, HashSet<Pair>>();
            Log = logger;
        }

        public Dictionary<string, HashSet<Pair>> Adj { get; private set; }

        public void AddEdge(RateBE model)
        {
            if (Adj.ContainsKey(model.From))
            {
                try
                {
                    Adj[model.From].Add(new Pair(model.To, model.Rate));
                }
                catch
                {
                    throw new VuelingExamDomainException(StringResources.EdgeExistsException);
                }
            }
            else
            {
                Pair pair = new Pair(model.To, model.Rate);
                var hs = new HashSet<Pair>();
                hs.Add(pair);
                Adj.Add(model.From, hs);
            }
        }
        public decimal RecursiveDFS(string start, string end)
        {
            decimal result;
            try
            {
                var visited = new HashSet<string>();
                Pair vertex = new Pair(start, 1);
                result = Traverse(vertex, visited, 1, end, false);
                result = Math.Round(result, 2);
            }
            #region Exceptions
            catch (ArgumentOutOfRangeException e)
            {
                Log.Error(e.Message);
                Log.Warning(e.StackTrace);
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            catch (OverflowException e)
            {
                Log.Error(e.Message);
                Log.Warning(e.StackTrace);
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                Log.Warning(e.StackTrace);
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            #endregion
            return result;
        }

        private decimal Traverse(Pair v, HashSet<string> visited, decimal resultRate,
            string end, bool found)
        {
            try
            {
                if (!found)
                {
                    visited.Add(v.First);
                    resultRate = resultRate * v.Second;
                    if (Adj.ContainsKey(v.First))
                    {
                        foreach (Pair neighbour in
                                Adj[v.First].Where(a => !visited.Contains(a.First)))
                        {
                            if (neighbour.First == end)
                                return Traverse(neighbour, visited, resultRate, end,
                                    (neighbour.First == end));
                        }
                        foreach (Pair neighbour in
                            Adj[v.First].Where(a => !visited.Contains(a.First)))
                        {
                            return Traverse(neighbour, visited, resultRate, end, neighbour.First == end);
                        }
                    }
                }
                else
                    return resultRate * v.Second;
            }
            #region Exceptions
            catch (ArgumentNullException e)
            {
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            #endregion
            return resultRate;
        }

        public BillBE GetBill(List<RateBE> rateList, List<TransactionBE> transactionList, string currency)
        {
            BillBE result = null;
            decimal rateValue = 0;
            decimal finalTipAmount = 0;
            List<TipBE> tipList = new List<TipBE>();
            try
            {
                for(int i = 0; i < transactionList.Count; i++)
                {
                    rateValue = Math.Round(GetTransactionAmount(transactionList[0], currency), 2);

                    decimal tipAmount = Math.Round(transactionList[i].Amount*0.05m, 2);

                    TipBE tip = new TipBE(transactionList[i].Sku, transactionList[i].Amount,
                        tipAmount, transactionList[i].Currency);

                    finalTipAmount += Math.Round(tipAmount * rateValue, 2);

                    tipList.Add(tip);
                }
                result = new BillBE(Math.Round(finalTipAmount, 2), currency, tipList);
            }
            #region Exceptions
            catch (ArgumentOutOfRangeException e)
            {
                Log.Error(e.Message);
                Log.Warning(e.StackTrace);
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            catch (OverflowException e)
            {
                Log.Error(e.Message);
                Log.Warning(e.StackTrace);
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                Log.Warning(e.StackTrace);
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            #endregion
            return result;
        }

        public decimal GetTransactionAmount(TransactionBE transaction, string currency)
        {
            decimal rateValue = 0;
            try
            {
                rateValue = RecursiveDFS(transaction.Currency, currency);
            }
            #region Exceptions
            catch (ArgumentOutOfRangeException e)
            {
                Log.Error(e.Message);
                Log.Warning(e.StackTrace);
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            catch (OverflowException e)
            {
                Log.Error(e.Message);
                Log.Warning(e.StackTrace);
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                Log.Warning(e.StackTrace);
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            #endregion
            return rateValue;
        }

        public void GenerateGraph(List<RateBE> rateList)
        {
            for (int i = 0; i < rateList.Count; i++)
            {
                AddEdge(rateList[i]);
            }
        }
    }
}
