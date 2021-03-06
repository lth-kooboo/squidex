﻿// ==========================================================================
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex UG (haftungsbeschränkt)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System.ComponentModel.DataAnnotations;
using System.Linq;
using Squidex.Domain.Apps.Entities.Apps;
using Squidex.Domain.Apps.Entities.Apps.Services;

namespace Squidex.Areas.Api.Controllers.Apps.Models
{
    public sealed class ContributorsDto
    {
        /// <summary>
        /// The contributors.
        /// </summary>
        [Required]
        public ContributorDto[] Contributors { get; set; }

        /// <summary>
        /// The maximum number of allowed contributors.
        /// </summary>
        public int MaxContributors { get; set; }

        public static ContributorsDto FromApp(IAppEntity app, IAppPlansProvider plans)
        {
            var plan = plans.GetPlanForApp(app);

            var contributors = app.Contributors.Select(x => new ContributorDto { ContributorId = x.Key, Permission = x.Value }).ToArray();

            return new ContributorsDto { Contributors = contributors, MaxContributors = plan.MaxContributors };
        }
    }
}
