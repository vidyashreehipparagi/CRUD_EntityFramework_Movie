using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CRUD_EntityFramework_Movie.Models
{
    public class MovieCrud
    {
       ApplicationDbContext context;
        private IConfiguration configuration;

        public MovieCrud(ApplicationDbContext context)
        {
            this.context = context;
        }

        public MovieCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return context.Movies.Where(x => x.IsActive == 1).ToList();
        }


        public Movie GetMovieById(int id)
        {
            var movie = context.Movies.Where(x => x.Id == id).FirstOrDefault();
            return movie;
        }


        public int AddMovie(Movie movie)
        {
            movie.IsActive = 1;
            int result = 0;
            context.Movies.Add(movie); // add new record in to the DbSet
            result = context.SaveChanges(); // update the change from DbSet to DB
            return result;
        }
        public int UpdateMovie(Movie movie)
        {

            int result = 0;
            // search from dbset
            var m = context.Movies.Where(x => x.Id == movie.Id).FirstOrDefault();
            if (m != null)
            {
               m.Mname = movie.Mname; // b object contains old data book obj contains new data
               m.ReleaseDate= movie.ReleaseDate;
               m.Genre = movie.Genre;
                m.StarsName = movie.StarsName;
               m.IsActive = 1;
                result = context.SaveChanges(); // update the change from DbSet to DB
            }

            return result;
        }
        public int DeleteMovie(int id)
        {


            int result = 0;
            // search from dbset
            var m = context.Movies.Where(x => x.Id == id).FirstOrDefault();
            if (m != null)
            {
                m.IsActive = 0;
                result = context.SaveChanges(); // update the change from DbSet to DB
            }


            return result;
        }


    }
}

