﻿using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieOverviewDataModel
    {
        public List<MovieViewModel> Movies { get; set; }
        public SidebarData SidebarData { get; set; }
    }
}
