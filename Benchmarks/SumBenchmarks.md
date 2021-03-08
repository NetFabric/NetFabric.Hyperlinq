## SumBenchmarks

### Source
[SumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SumBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   440.16 ns | 1.485 ns | 1.240 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                    StructLinq_Array |                     Array |   100 |    63.85 ns | 0.391 ns | 0.305 ns |  0.15 |      - |     - |     - |         - |
|                LinqFasterSIMD_Array |                     Array |   100 |    11.77 ns | 0.043 ns | 0.040 ns |  0.03 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    23.48 ns | 0.071 ns | 0.063 ns |  0.05 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    23.68 ns | 0.085 ns | 0.075 ns |  0.05 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    24.58 ns | 0.050 ns | 0.041 ns |  0.06 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   652.60 ns | 3.675 ns | 3.438 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   630.10 ns | 4.154 ns | 3.469 ns |  0.97 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   224.38 ns | 0.425 ns | 0.376 ns |  0.34 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   657.58 ns | 1.698 ns | 1.588 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   660.39 ns | 2.786 ns | 2.327 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   224.88 ns | 0.486 ns | 0.454 ns |  0.34 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   662.89 ns | 2.929 ns | 2.740 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_List_Value |                List_Value |   100 |   232.45 ns | 1.216 ns | 1.138 ns |  0.35 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   227.53 ns | 1.574 ns | 1.314 ns |  0.34 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,176.24 ns | 7.351 ns | 6.139 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,293.51 ns | 3.706 ns | 3.285 ns |  0.59 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   435.03 ns | 2.285 ns | 2.138 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   433.33 ns | 2.677 ns | 2.373 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   461.59 ns | 3.571 ns | 2.982 ns |  1.06 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   442.60 ns | 1.511 ns | 1.340 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   434.03 ns | 1.654 ns | 1.547 ns |  0.98 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   436.92 ns | 2.885 ns | 2.699 ns |  0.99 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   444.02 ns | 2.263 ns | 1.889 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   410.29 ns | 1.794 ns | 1.498 ns |  0.92 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   228.02 ns | 1.067 ns | 0.946 ns |  0.51 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,034.33 ns | 7.334 ns | 6.501 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,003.81 ns | 4.815 ns | 4.269 ns |  0.99 | 0.0191 |     - |     - |      40 B |
