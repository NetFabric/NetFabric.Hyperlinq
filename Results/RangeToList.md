## RangeToList

- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Start | Count |     Mean |    Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |---------:|---------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 | 287.0 ns |  3.44 ns | 3.22 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
| ForeachLoop |     0 |   100 | 728.8 ns | 10.85 ns | 9.06 ns |  2.54 |    0.05 | 0.5922 |     - |     - |    1240 B |
|        Linq |     0 |   100 | 187.6 ns |  2.03 ns | 1.90 ns |  0.65 |    0.01 | 0.2370 |     - |     - |     496 B |
|  LinqFaster |     0 |   100 | 117.1 ns |  1.51 ns | 1.41 ns |  0.41 |    0.01 | 0.4207 |     - |     - |     880 B |
|  StructLinq |     0 |   100 | 281.5 ns |  5.51 ns | 5.66 ns |  0.98 |    0.03 | 0.5774 |     - |     - |    1208 B |
|   Hyperlinq |     0 |   100 | 100.3 ns |  1.13 ns | 1.00 ns |  0.35 |    0.01 | 0.2333 |     - |     - |     488 B |
