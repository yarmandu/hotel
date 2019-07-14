
using System.Collections.Generic;
using Proyecto_Hoteleria.Models;
using Proyecto_Hoteleria.Models.ReservaVM;
using AutoMapper;
using System.Web.Mvc;
using Modelo_Entidades;

namespace Proyecto_Hoteleria.Mapas
{
    public class ProtectoHoteleriaMapper:Profile
    {
        protected override void Configure()
        {
            #region Cliente
            Mapper.CreateMap<Cliente, ClienteVM>();
            Mapper.CreateMap<ClienteVM, Cliente>();
            #endregion

            #region Cliente
            Mapper.CreateMap<Habitacion, HabitacionVM>();
            Mapper.CreateMap<HabitacionVM, Habitacion>();
            #endregion

            #region Cliente
            Mapper.CreateMap<ReservaHabitacion, ReservaHabitacionVM >();
            Mapper.CreateMap<ReservaHabitacionVM, ReservaHabitacion>();
            #endregion

            #region TipoDocumento
            Mapper.CreateMap<TipoDocumento, SelectListItem>()
                .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.tipoDocumento))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.IdTipoDocumento));
            Mapper.CreateMap<IEnumerable<TipoDocumento>, IList<SelectListItem>>();
            #endregion

            #region TipoSexo
            Mapper.CreateMap<Sexo, SelectListItem>()
                .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.tipoSexo))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.IdTipoSexo));
            Mapper.CreateMap<IEnumerable<Sexo>, IList<SelectListItem>>();
            #endregion

            #region TipoCliente
            Mapper.CreateMap<TipoCliente, SelectListItem>()
                .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.tipoCliente))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.IdTipoCliente));
            Mapper.CreateMap<IEnumerable<TipoCliente>, IList<SelectListItem>>();
            #endregion

            #region TipoResidencia
            Mapper.CreateMap<Residencia, SelectListItem>()
                .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.tipoResidencia))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.IdTipoResidencia));
            Mapper.CreateMap<IEnumerable<Residencia>, IList<SelectListItem>>();
            #endregion

            #region TipoHabitacion
            Mapper.CreateMap<TipoHabitacion, SelectListItem>()
                .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.tipoHabitacion))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.idTipoHabitacion));
            Mapper.CreateMap<IEnumerable<TipoHabitacion>, IList<SelectListItem>>();
            #endregion

            #region TipoServicio
            Mapper.CreateMap<TipoServicio, SelectListItem>()
                .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.tipoServicio))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.idtipoServicio));
            Mapper.CreateMap<IEnumerable<TipoServicio>, IList<SelectListItem>>();
            #endregion

            #region TipoPago
            Mapper.CreateMap<TipoPago, SelectListItem>()
                .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.tipoPago))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.idtipoPago));
            Mapper.CreateMap<IEnumerable<TipoPago>, IList<SelectListItem>>();
            #endregion

        }
    }
}