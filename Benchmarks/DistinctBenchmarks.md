## DistinctBenchmarks

### Source
[DistinctBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/DistinctBenchmarks.cs)

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
|                              Method |                Categories | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 2.999 μs | 0.0128 μs | 0.0113 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|                    StructLinq_Array |                     Array |   100 | 1.355 μs | 0.0058 μs | 0.0054 μs |  0.45 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 | 1.468 μs | 0.0048 μs | 0.0042 μs |  0.49 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.465 μs | 0.0055 μs | 0.0052 μs |  0.49 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.574 μs | 0.0053 μs | 0.0041 μs |  0.53 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 3.241 μs | 0.0096 μs | 0.0085 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.270 μs | 0.0083 μs | 0.0073 μs |  0.70 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1.532 μs | 0.0072 μs | 0.0064 μs |  0.47 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 3.235 μs | 0.0116 μs | 0.0109 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.280 μs | 0.0117 μs | 0.0097 μs |  0.70 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1.511 μs | 0.0062 μs | 0.0052 μs |  0.47 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 3.258 μs | 0.0168 μs | 0.0158 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|               StructLinq_List_Value |                List_Value |   100 | 1.533 μs | 0.0049 μs | 0.0043 μs |  0.47 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 1.885 μs | 0.0054 μs | 0.0048 μs |  0.58 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7.954 μs | 0.0214 μs | 0.0189 μs |  1.00 | 2.0599 |     - |     - |    4328 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4.731 μs | 0.0183 μs | 0.0162 μs |  0.59 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.992 μs | 0.0121 μs | 0.0101 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1.625 μs | 0.0086 μs | 0.0076 μs |  0.54 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1.957 μs | 0.0042 μs | 0.0037 μs |  0.65 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 2.986 μs | 0.0087 μs | 0.0077 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1.633 μs | 0.0047 μs | 0.0039 μs |  0.55 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1.956 μs | 0.0078 μs | 0.0073 μs |  0.65 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 2.993 μs | 0.0110 μs | 0.0091 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1.628 μs | 0.0067 μs | 0.0059 μs |  0.54 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1.882 μs | 0.0078 μs | 0.0065 μs |  0.63 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7.822 μs | 0.0163 μs | 0.0145 μs |  1.00 | 2.0599 |     - |     - |    4328 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5.085 μs | 0.0164 μs | 0.0146 μs |  0.65 | 0.0153 |     - |     - |      40 B |
