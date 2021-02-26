using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Application.Interfaces;
using MarsRover.Application.Models;
using MarsRover.Interfaces;
using MarsRover.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MarsRover.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICommandCenterService _commandCenterService;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public CommandCenterViewModel ViewModel { get; set; }

        public IndexModel(ICommandCenterService commandCenterService, ILogger<IndexModel> logger)
        {
            _commandCenterService = commandCenterService;
            _logger = logger;
        }
        public void OnGet(string commandCenterViewModelJson = "")
        {
            CommandCenterViewModel viewModel = JsonConvert.DeserializeObject<CommandCenterViewModel>(commandCenterViewModelJson);
            ViewModel = viewModel ?? new CommandCenterViewModel();
        } 

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                ViewModel = _commandCenterService.ExecuteCommands(ViewModel);
            }
            catch(Exception e)
            {
                TempData["ErrorMessage"] = "An error has occurred while executing commands. Please check input and try again. If problem persists, contact IT";
                _logger.LogError(e, "Error executing commands. CommandCenterViewModel: {@CommandCenterviewModel}", ViewModel);
            }

            return RedirectToAction("Index", new { commandCenterViewModelJson = JsonConvert.SerializeObject(ViewModel) });
        }
    }
}
