## RepeatToArrayBenchmarks

### Source
[RepeatToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-KXCEYC : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|          Method |   Categories | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 |  91.48 ns | 0.341 ns | 0.285 ns |  1.00 | 0.2180 |     - |     - |     456 B |
|      StructLinq |       Repeat |   100 | 110.52 ns | 0.520 ns | 0.461 ns |  1.21 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Repeat |   100 |  28.03 ns | 0.611 ns | 0.654 ns |  0.31 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Repeat |   100 |  55.85 ns | 0.942 ns | 1.122 ns |  0.61 | 0.2027 |     - |     - |     424 B |
|  Hyperlinq_SIMD |       Repeat |   100 |  40.77 ns | 0.343 ns | 0.304 ns |  0.45 | 0.2027 |     - |     - |     424 B |
|                 |              |       |           |          |          |       |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 |  92.87 ns | 0.784 ns | 0.733 ns |  1.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Repeat_Async |   100 | 118.72 ns | 0.475 ns | 0.422 ns |  1.28 | 0.2027 |     - |     - |     424 B |
