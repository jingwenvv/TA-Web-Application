/*
  Author:    Jingwen Zhang
  Partner:   -Na -
  Date:      2021 / 10 / 24
  Course: CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Jingwen Zhang - This work may not be copied for use in Academic Coursework.

  I, Jingwen Zhang, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TA__Application.Areas.Identity.Data;

namespace TA__Application.Data
{
    public class TAUsersRolesDB : IdentityDbContext<TAUser>
    {
        public TAUsersRolesDB(DbContextOptions<TAUsersRolesDB> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
