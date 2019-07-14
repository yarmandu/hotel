using AutoMapper;
using Proyecto_Hoteleria.Mapas;

namespace Proyecto_Hoteleria.Mapas
{
    public class MapperInitial
    {
        public static void Init()
        {
            Mapper.Initialize(x => x.AddProfile(new ProtectoHoteleriaMapper()));
        }
    }
}