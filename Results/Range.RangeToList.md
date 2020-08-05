## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 | 301.3 ns | 2.36 ns | 2.21 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
| ForeachLoop |     0 |   100 | 748.1 ns | 4.91 ns | 4.36 ns |  2.48 |    0.03 | 0.5922 |     - |     - |    1240 B |
|        Linq |     0 |   100 | 189.2 ns | 0.87 ns | 0.68 ns |  0.63 |    0.00 | 0.2370 |     - |     - |     496 B |
|  LinqFaster |     0 |   100 | 118.0 ns | 0.52 ns | 0.46 ns |  0.39 |    0.00 | 0.4206 |     - |     - |     880 B |
|  StructLinq |     0 |   100 | 374.4 ns | 2.48 ns | 2.20 ns |  1.24 |    0.01 | 0.2294 |     - |     - |     480 B |
|   Hyperlinq |     0 |   100 | 100.3 ns | 0.44 ns | 0.39 ns |  0.33 |    0.00 | 0.2333 |     - |     - |     488 B |
