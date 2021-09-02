using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Services;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolicitudAyuda.Tests
{
    [TestFixture]
    public class SolicitudAyudaServiceTests
    {
        private DataContext db;
        private IConfiguration config;
        IFileStorageService fileStorageService;
        IPermisosService permisosService;

        [SetUp]
        public void Setup()
        {
            var data = new List<SolicitudAyuda.Model.Entities.SolicitudAyuda>
            {
                new Model.Entities.SolicitudAyuda { Id = 1, EstadoId = 1, Maestro = new Maestro(), TipoSolicitud = new TipoSolicitud(), Estado = new EstadoSolicitud(), Seccional = new Seccional()  },
                new Model.Entities.SolicitudAyuda { Id = 2, EstadoId = 2, Maestro = new Maestro(), TipoSolicitud = new TipoSolicitud(), Estado = new EstadoSolicitud(), Seccional = new Seccional()  },
                new Model.Entities.SolicitudAyuda { Id = 3, EstadoId = 3, Maestro = new Maestro(), TipoSolicitud = new TipoSolicitud(), Estado = new EstadoSolicitud(), Seccional = new Seccional()  },
                new Model.Entities.SolicitudAyuda { Id = 4, EstadoId = 4, Maestro = new Maestro(), TipoSolicitud = new TipoSolicitud(), Estado = new EstadoSolicitud(), Seccional = new Seccional()  },
                new Model.Entities.SolicitudAyuda { Id = 5, EstadoId = 5, Maestro = new Maestro(), TipoSolicitud = new TipoSolicitud(), Estado = new EstadoSolicitud(), Seccional = new Seccional()  }
            }.AsQueryable();

            var moqSet = new Mock<DbSet<SolicitudAyuda.Model.Entities.SolicitudAyuda>>();

            moqSet.As<IQueryable<SolicitudAyuda.Model.Entities.SolicitudAyuda>>()
                .Setup(m => m.Provider).Returns(data.Provider);

            moqSet.As<IQueryable<SolicitudAyuda.Model.Entities.SolicitudAyuda>>()
                .Setup(m => m.Expression).Returns(data.Expression);

            moqSet.As<IQueryable<SolicitudAyuda.Model.Entities.SolicitudAyuda>>()
                .Setup(m => m.ElementType).Returns(data.ElementType);

            moqSet.As<IQueryable<SolicitudAyuda.Model.Entities.SolicitudAyuda>>()
                .Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            DbContextOptions options = new DbContextOptionsBuilder<DataContext>().Options;
            var contextMoq = new Mock<DataContext>(options);
            contextMoq.Setup(c => c.Solicitudes).Returns(moqSet.Object);

            this.db = contextMoq.Object;

            
            this.config = new Mock<IConfiguration>().Object;
            this.fileStorageService = new Mock<IFileStorageService>().Object;
            this.permisosService = new Mock<IPermisosService>().Object;
            ///DataContext db, IConfiguration config, IFileStorageService fileStorageService, IPermisosService permisosService
        }

        [Test]
        public void GetDataConsulta_WhenCalledWithOutFilters_ReturnsAllSolicitudes()
        {
            //Arrange
            SolicitudesService service = new SolicitudesService(db, config, fileStorageService, permisosService);

            var filtro = new FiltroSolicitudesDTO();
            
            //Act
            var result = service.GetDataConsulta(filtro).TotalItems;

            var expected = 5;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetDataConsulta_WhenCalledWithEstado_ReturnsSolicitudesWithThatEstado() 
        {
            SolicitudesService service = new SolicitudesService(db, config, fileStorageService, permisosService);

            var filtro = new FiltroSolicitudesDTO
            {
                Page = 1,
                ItemsPerPage = 10,
                Estados = new List<int> { 1, 2 }
            };

            var expected = new List<SolicitudConsultaDTO>
            {
                new SolicitudConsultaDTO { Id = 1, EstadoId = 1 },
                new SolicitudConsultaDTO { Id = 2, EstadoId = 2 },
            };

            var result = service.GetDataConsulta(filtro);

            Assert.That(expected, Is.EquivalentTo(result.Data));
        }
    }
}
