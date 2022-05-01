using ApiTutorial.Models;
using ApiTutorial.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private RepositoryPeliculas repo;

        public PeliculasController(RepositoryPeliculas repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Pelicula>> GetPeliculas()
        {
            return this.repo.GetPeliculas();
        }

        [HttpGet("{id}")]
        public ActionResult<Pelicula> FindPelicula(int id)
        {
            return this.repo.GetPeliculaDetails(id);
        }

        [HttpPost]
        public ActionResult PostPelicula(Pelicula peli)
        {
            this.repo.InsertarPelicula(peli.Titulo, peli.Duracion, peli.Sinopsis, peli.Genero, peli.Trailer, peli.Imagen, peli.Valoracion);
            return Ok();
        }

        [HttpPut]
        public ActionResult PutPelicula(Pelicula peli)
        {
            this.repo.ModificarPelicula(peli.IdPelicula, peli.Titulo, peli.Duracion, peli.Sinopsis, peli.Genero, peli.Trailer, peli.Imagen, peli.Valoracion);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePelicula(int id)
        {
            this.repo.DeletePelicula(id);
            return Ok();
        }
    }
}
