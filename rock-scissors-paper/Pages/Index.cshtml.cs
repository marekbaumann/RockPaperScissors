using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using rock_scissors_paper.Model;

namespace rock_scissors_paper.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Choice Player { get; set; }
        public Choice Computer { get; set; }

        [BindProperty]
        public int Round { get; set; }

        [BindProperty]
        public int Wins { get; set; }

        [BindProperty]
        public int Lose { get; set; }

        private Random _random;

        [BindProperty]
        public int Draw { get; set; }

        [BindProperty]
        public int Rock { get; set; }

        [BindProperty]
        public int Paper { get; set; }

        [BindProperty]
        public int Scissors { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _random = new Random();
        }

        public void OnGet()
        {
            Player = Choice.None;
            Computer = Choice.None;
        }
        public void OnPost()
        {
            Computer = (Choice)_random.Next(1,4);
            Round++;
            if(Player != Computer)
            {
                if (
                    (Player == Choice.Rock && Computer == Choice.Scissors) ||
                    (Player == Choice.Scissors && Computer == Choice.Paper) ||
                    (Player == Choice.Paper && Computer == Choice.Rock)
                   )
                {
                    Wins++;
                }
                else Lose++;
            }
            else
            {
                Draw++;
            }
            if(Player == Choice.Rock)
            {
                Rock++;
            }
            if (Player == Choice.Scissors)
            {
                Scissors++;
            }
            if(Player == Choice.Paper)
            {
                Paper++;
            }
        }
    }
}
