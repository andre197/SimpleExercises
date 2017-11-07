﻿namespace GraphsProject
{
    public class MatrixVertex<T> : IVertex<T>
    {
        public (int, int) Index { get; set; }

        public T Data { get; set; } 
    }
}
