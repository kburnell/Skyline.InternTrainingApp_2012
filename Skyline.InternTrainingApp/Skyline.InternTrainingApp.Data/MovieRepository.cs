﻿using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.InternTrainingApp.Common.BaseClasses;
using Skyline.InternTrainingApp.Common.Domain;
using Skyline.InternTrainingApp.Common.Interfaces.Data;

namespace Skyline.InternTrainingApp.Data {

    public class MovieRepository : RepositoryBase, IMovieRepository  {

        public IList<Movie> All() {
            EnsureUnitOfWorkHasBeenSet();
            return Context.Movies.Include("Genres").ToList();
        }

        public Movie GetByID(long id) {
            throw new System.NotImplementedException();
        }

        public void Maintain(Movie t) {
            throw new System.NotImplementedException();
        }

        public Movie GetByTitle(string title) {
            EnsureUnitOfWorkHasBeenSet();
            return Context.Movies.First(x => x.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}