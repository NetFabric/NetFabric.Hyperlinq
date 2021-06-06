## RepeatBenchmarks

### Source
[RepeatBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|          Method |   Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 |   393.35 ns |  1.375 ns |  1.219 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      StructLinq |       Repeat |   100 |    44.33 ns |  0.164 ns |  0.154 ns |  0.11 |      - |     - |     - |         - |
|       Hyperlinq |       Repeat |   100 |   147.06 ns |  0.308 ns |  0.288 ns |  0.37 |      - |     - |     - |         - |
|                 |              |       |             |           |           |       |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 | 4,710.88 ns | 21.558 ns | 20.165 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Async | Repeat_Async |   100 |   770.99 ns |  4.354 ns |  3.636 ns |  0.16 |      - |     - |     - |         - |
