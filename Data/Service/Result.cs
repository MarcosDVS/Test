using Test.Data.Context;
using Test.Data.Model;
using Test.Data.Request;
using Test.Data.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Data.Services;

public class Result
{
    public bool Success { get; set; }
    public string? Message { get; set; }
}

public class Result<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}