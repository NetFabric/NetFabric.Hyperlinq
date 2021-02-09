## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                    Method | Start | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 256.55 ns | 0.413 ns | 0.345 ns |  0.89 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 506.83 ns | 1.979 ns | 1.851 ns |  1.76 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 401.86 ns | 0.969 ns | 0.810 ns |  1.39 | 0.2179 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 528.71 ns | 1.340 ns | 1.187 ns |  1.83 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 288.50 ns | 1.861 ns | 1.741 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 759.68 ns | 2.592 ns | 2.298 ns |  2.63 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 216.73 ns | 0.893 ns | 0.791 ns |  0.75 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 117.93 ns | 1.053 ns | 0.933 ns |  0.41 | 0.4206 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 299.83 ns | 2.101 ns | 1.862 ns |  1.04 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 |  89.04 ns | 0.407 ns | 0.361 ns |  0.31 | 0.2180 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 | 104.06 ns | 0.683 ns | 0.639 ns |  0.36 | 0.2333 |     - |     - |     488 B |
