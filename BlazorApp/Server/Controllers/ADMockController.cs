using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    /// <summary>
    /// Заглушка для сервиса поиска данных в АД
    /// </summary>
    [Route("api/ADMock")]
    [ApiController]
    public class AdMockController : ControllerBase
    {
        private readonly List<UserAd> _users;

        public AdMockController()
        {
            _users = new List<UserAd>
            {
                new() {Name = "Иванов Иван Иванович", Login = @"main\Ivanov.Ivan"},
                new() {Name = "Петров Петр Петрович", Login = @"main\Petrov.Petr"},
                new() { Name = "Иванов Алексей Алексеевич", Login = @"main\Ivanov.Aleksey" }
            };
        }

        /// <summary>
        /// Заглушка для получения пользователей AD
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserAd> Get(string login)
        {
            // задержка 
            Thread.Sleep(5000);
            return _users.Where(u => u.Login == login).ToList();
        }
    }
}
