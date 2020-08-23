## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

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
|     ForLoop |     0 |   100 | 287.9 ns | 3.07 ns | 2.87 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
| ForeachLoop |     0 |   100 | 786.4 ns | 3.81 ns | 3.38 ns |  2.73 |    0.03 | 0.5922 |     - |     - |    1240 B |
|        Linq |     0 |   100 | 213.7 ns | 1.37 ns | 1.28 ns |  0.74 |    0.01 | 0.2370 |     - |     - |     496 B |
|  LinqFaster |     0 |   100 | 124.8 ns | 1.03 ns | 0.91 ns |  0.43 |    0.01 | 0.4206 |     - |     - |     880 B |
|      LinqAF |     0 |   100 | 295.8 ns | 3.01 ns | 2.67 ns |  1.03 |    0.01 | 0.2179 |     - |     - |     456 B |
|  StructLinq |     0 |   100 | 227.1 ns | 1.16 ns | 0.97 ns |  0.79 |    0.01 | 0.2179 |     - |     - |     456 B |
|   Hyperlinq |     0 |   100 | 131.2 ns | 1.04 ns | 0.97 ns |  0.46 |    0.00 | 0.2332 |     - |     - |     488 B |
