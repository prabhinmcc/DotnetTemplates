﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Application.Activities;
using Domain;

namespace WebAPITemplate.Controllers
{

    public class ActivitiesController : BaseApiController
    {
        public ActivitiesController()
        {
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivities(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });

        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            await Mediator.Send(new Create.Command { Activity = activity });
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, [FromBody] Activity activity)
        {
            activity.Id = id;
            await Mediator.Send(new Edit.Command { Activity = activity });
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await Mediator.Send(new Delete.Command
            {
                Guid = id
            });

            return Ok();
        }
    }
}
