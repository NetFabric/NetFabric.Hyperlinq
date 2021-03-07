## SelectCountBenchmarks

### Source
[SelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectCountBenchmarks.cs)

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
|                              Method |                Categories | Count |          Mean |      Error |     StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|-----------:|-----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    224.277 ns |  0.4345 ns |  0.3628 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |     10.150 ns |  0.0199 ns |  0.0166 ns |  0.05 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     15.361 ns |  0.0338 ns |  0.0316 ns |  0.07 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |     15.171 ns |  0.0257 ns |  0.0228 ns |  0.07 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |     15.672 ns |  0.0299 ns |  0.0265 ns |  0.07 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |    759.681 ns |  3.1555 ns |  2.7973 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |    732.019 ns |  2.7600 ns |  2.4466 ns |  0.96 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |    151.104 ns |  0.5293 ns |  0.4692 ns |  0.20 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    758.326 ns |  2.2525 ns |  1.9968 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |    764.524 ns |  2.6022 ns |  2.4341 ns |  1.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     12.307 ns |  0.0410 ns |  0.0383 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    391.641 ns |  1.4831 ns |  1.3873 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|               StructLinq_List_Value |                List_Value |   100 |     10.500 ns |  0.0256 ns |  0.0227 ns |  0.03 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |      9.545 ns |  0.0280 ns |  0.0233 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  8,726.288 ns | 21.4842 ns | 20.0963 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  8,683.065 ns | 26.4846 ns | 24.7737 ns |  1.00 | 0.0610 |     - |     - |     136 B |
|                                     |                           |       |               |            |            |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |    591.862 ns |  1.6890 ns |  1.4972 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |    547.755 ns |  0.9714 ns |  0.8611 ns |  0.93 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |    260.682 ns |  0.6990 ns |  0.6538 ns |  0.44 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |            |            |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    547.362 ns |  1.9407 ns |  1.7203 ns | 1.000 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |    595.461 ns |  1.8425 ns |  1.7235 ns | 1.088 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |      4.758 ns |  0.0162 ns |  0.0135 ns | 0.009 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    433.732 ns |  1.6018 ns |  1.4983 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|           StructLinq_List_Reference |            List_Reference |   100 |    550.477 ns |  2.3860 ns |  2.2318 ns |  1.27 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |      9.898 ns |  0.0138 ns |  0.0129 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  8,678.596 ns | 33.2571 ns | 27.7712 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 10,073.240 ns | 21.6052 ns | 19.1524 ns |  1.16 | 0.0610 |     - |     - |     152 B |
