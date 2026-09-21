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
        public object AddNewBlogger([FromBody] AddNewBloggerPostDto addNewBloggerPostDto)
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            string sql = @"INSERT INTO `blogpost`(`Title`, `Content`, `postTime`, `updateTime`, `blog`) VALUES (@Title, @Content, @postTime,@updateTime, @blogId)";

            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@title", addNewBloggerPostDto.Title);
            cmd.Parameters.AddWithValue("@content", addNewBloggerPostDto.Content);
            cmd.Parameters.AddWithValue("@postTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@updateTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@blogId", addNewBloggerPostDto.blogId);

            cmd.ExecuteNonQuery();

            connection.Close();
            return new { massage = "Sikeres felvétel", result = addNewBloggerPostDto };
        }
    }
}
