using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Web.Mvc;
using plejmo_wants_you.Models;

namespace plejmo_wants_you.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new List<Movie>();
            var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["plejmo-wants-you"].ConnectionString);
            var command = new SQLiteCommand("SELECT Movies.Title, AVG(Ratings.Rating) AverageRating FROM Ratings INNER JOIN Movies ON Movies.Id = Ratings.MovieId GROUP BY Ratings.MovieId ORDER BY AverageRating DESC;", connection);
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var movie = new Movie();
                movie.Title = reader.GetString(0);
                movie.AverageRating = reader.GetDecimal(1);
                model.Add(movie);
            }
            reader.Close();
            command.Dispose();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string title, string userId, string rating)
        {
            var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["plejmo-wants-you"].ConnectionString);
            var command = new SQLiteCommand(connection);
            connection.Open();
            command.CommandText = "SELECT Id FROM Movies WHERE Title = '" + title + "'";
            var movieId = Convert.ToString(command.ExecuteScalar());
            command.CommandText = "DELETE FROM Ratings WHERE UserId = " + userId + " AND MovieId = " + movieId;
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Ratings (UserId, MovieId, Rating) VALUES (" + userId + "," + movieId + "," + rating + ");";
            command.ExecuteNonQuery();
            command.Dispose();
            return Redirect("/");
        }
    }
}