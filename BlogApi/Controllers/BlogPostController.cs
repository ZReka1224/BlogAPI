using BlogApi.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        public string ConnectionString = "server=localhost;uid=root;password=;database=blog;";

        [HttpPost]
        public object AddNewBlogger([FromBody] AddNewBloggerDto addNewBloggerDto)
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            string sql = @"INSERT INTO `blogpost`(`id`, `blog_id`, `title`, `content`, `created_at`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]')";

            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@name", addNewBloggerDto.Name);
            cmd.Parameters.AddWithValue("@email", addNewBloggerDto.Email);
            cmd.Parameters.AddWithValue("@age", addNewBloggerDto.Age);
            cmd.Parameters.AddWithValue("@password", addNewBloggerDto.Password);
            cmd.Parameters.AddWithValue("@registrationtime", DateTime.Now);

            cmd.ExecuteNonQuery();

            connection.Close();
            return new { massage = "Sikeres felvétel", result = addNewBloggerDto };
        }
    }
}
