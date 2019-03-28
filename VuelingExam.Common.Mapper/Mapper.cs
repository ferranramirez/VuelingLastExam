using AutoMapper;
using System.Collections.Generic;

namespace VuelingExam.Common.Mapper
{
    public class Mapper
    {
        public U Map<T, U>(T origin)
        {
            IMapper mapper = MapCreator<T, U>();
            return mapper.Map<T, U>(origin);
        }

        public List<U> MapList<T, U>(List<T> origin)
        {
            IMapper mapper = MapCreator<T, U>();
            return mapper.Map<List<T>, List<U>>(origin);
        }

        public Dictionary<V, List<W>> MapDictionary<T, U, V, W>(
            Dictionary<T, List<U>> origin)
        {
            IMapper mapper = MapCreator<T, U>();
            return mapper.Map<Dictionary<T, List<U>>,
                Dictionary<V, List<W>>>(origin);
        }

        private static IMapper MapCreator<T, U>()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, U>());
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
