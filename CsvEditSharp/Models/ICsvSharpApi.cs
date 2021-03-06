﻿using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;

namespace CsvEditSharp.Models
{
    public interface ICsvEditSharpApi
    {
        Encoding Encoding { get; set; }

        CsvConfiguration CsvConfiguration { get; set; }

        ClassMap ClassMapForReading { get; }

        ClassMap ClassMapForWriting { get; }

        IDictionary<string, ColumnValidation> ColumnValidations { get; }

        ICsvEditSharpApi GetCsvEditSharpApi();

        void RegisterClassMap<T>(Action<ClassMap<T>> propertyMapSetter = null);

        void RegisterClassMapForReading<T>(Action<ClassMap<T>> propertyMapSetter = null);

        void RegisterClassMapForWriting<T>(Action<ClassMap<T>> propertyMapSetter = null);

        void AddValidation<TType, TMember>(Expression<Func<TType, TMember>> memberSelector, Func<TMember, bool> validation, string errorMessage);

        void Query<T>(Func<IEnumerable<T>, IEnumerable<T>> query);

        void Query<T>(Action<IEnumerable<T>> query);
    }

}
