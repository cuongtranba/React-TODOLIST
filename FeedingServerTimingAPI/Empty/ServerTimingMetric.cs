﻿using System;
using System.Globalization;

namespace Empty
{
    public struct ServerTimingMetric
    {
        private string _serverTimingMetric;
        public string Name { get; }
        public decimal? Value { get; }
        public string Description { get; }
        public ServerTimingMetric(string name, decimal? value, string description)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            Name = name;
            Value = value;
            Description = description;
            _serverTimingMetric = null;
        }
        public override string ToString()
        {
            if (_serverTimingMetric == null)
            {
                _serverTimingMetric = Name;
                if (Value.HasValue)
                    _serverTimingMetric = $"{_serverTimingMetric}={Value.Value.ToString(CultureInfo.InvariantCulture)}";
                if (!String.IsNullOrEmpty(Description))
                    _serverTimingMetric = $"{_serverTimingMetric};\"{Description}\"";
            }
            return _serverTimingMetric;
        }
    }
}
