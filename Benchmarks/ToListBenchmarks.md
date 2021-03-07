## ToListBenchmarks

### Source
[ToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToListBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    55.12 ns | 0.522 ns | 0.463 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |   114.59 ns | 0.411 ns | 0.365 ns |  2.08 |    0.02 | 0.2180 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    45.01 ns | 0.405 ns | 0.359 ns |  0.82 |    0.01 | 0.2180 |     - |     - |     456 B |
|                      Hyperlinq_Span |                     Array |   100 |    44.28 ns | 0.465 ns | 0.435 ns |  0.80 |    0.01 | 0.2180 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |    46.01 ns | 0.551 ns | 0.515 ns |  0.83 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   872.93 ns | 5.091 ns | 4.513 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   921.94 ns | 4.735 ns | 3.954 ns |  1.06 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   524.08 ns | 1.978 ns | 1.652 ns |  0.60 |    0.00 | 0.2365 |     - |     - |     496 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    47.75 ns | 0.457 ns | 0.382 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   919.13 ns | 3.099 ns | 2.588 ns | 19.25 |    0.14 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   289.67 ns | 1.353 ns | 1.266 ns |  6.07 |    0.06 | 0.2370 |     - |     - |     496 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    49.38 ns | 0.505 ns | 0.472 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   250.76 ns | 0.585 ns | 0.518 ns |  5.07 |    0.05 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   540.22 ns | 1.680 ns | 1.403 ns | 10.92 |    0.08 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   656.17 ns | 3.887 ns | 3.246 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   695.62 ns | 2.024 ns | 1.794 ns |  1.06 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   814.58 ns | 2.932 ns | 2.743 ns |  1.24 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    48.59 ns | 0.109 ns | 0.085 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   696.40 ns | 1.208 ns | 1.130 ns | 14.33 |    0.03 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   491.19 ns | 1.904 ns | 1.688 ns | 10.11 |    0.04 | 0.2441 |     - |     - |     512 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    49.74 ns | 0.485 ns | 0.430 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   695.08 ns | 2.968 ns | 2.777 ns | 13.98 |    0.11 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   540.32 ns | 1.604 ns | 1.252 ns | 10.87 |    0.09 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,702.46 ns | 4.809 ns | 4.499 ns |     ? |       ? | 0.5798 |     - |     - |    1216 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,372.23 ns | 5.156 ns | 4.823 ns |     ? |       ? | 0.5989 |     - |     - |    1256 B |
