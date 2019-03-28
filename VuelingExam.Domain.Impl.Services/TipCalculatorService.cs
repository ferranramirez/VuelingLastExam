using System;
using System.Collections.Generic;
using System.Linq;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Contract.Services;

namespace VuelingExam.Domain.Impl.Services
{
    public class TipCalculatorService : ITipCalculatorService
    {
        public TipCalculatorService()
        {
            Adj = new Dictionary<string, HashSet<Pair>>();
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
                    Console.WriteLine("This edge already exists: " + model.From + " to " + model.To);
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
            var visited = new HashSet<string>();
            Pair vertex = new Pair(start, 1);
            decimal result = Traverse(vertex, visited, 1, end, false);
            return Math.Round(result, 2);
        }

        private decimal Traverse(Pair v, HashSet<string> visited, decimal resultRate,
            string end, bool found)
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
                            return Traverse(neighbour, visited, resultRate, end, (neighbour.First == end));
                    }
                    foreach (Pair neighbour in 
                        Adj[v.First].Where(a => !visited.Contains(a.First)))
                    {
                        return Traverse(neighbour, visited, resultRate, end, (neighbour.First == end));
                    }
                }
            }
            else
            {
                return resultRate * v.Second;
            }
            return resultRate;
        }

        public decimal GetTip(List<RateBE> rateList, TransactionBE transaction, string currency)
        {
            decimal rateValue = RecursiveDFS(transaction.Currency, currency);
            decimal finalAmount = transaction.Amount * rateValue;
            return finalAmount;
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
