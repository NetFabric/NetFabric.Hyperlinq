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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|          Method |   Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 |   388.03 ns |  2.670 ns |  2.367 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      StructLinq |       Repeat |   100 |    44.37 ns |  0.187 ns |  0.146 ns |  0.11 |      - |     - |     - |         - |
|       Hyperlinq |       Repeat |   100 |   147.12 ns |  0.422 ns |  0.395 ns |  0.38 |      - |     - |     - |         - |
|                 |              |       |             |           |           |       |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 | 4,715.35 ns | 18.267 ns | 15.253 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Async | Repeat_Async |   100 |   795.54 ns |  1.931 ns |  1.711 ns |  0.17 |      - |     - |     - |         - |
