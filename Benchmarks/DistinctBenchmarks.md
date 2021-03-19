## DistinctBenchmarks

### Source
[DistinctBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/DistinctBenchmarks.cs)

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
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 2.886 μs | 0.0206 μs | 0.0193 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|                    StructLinq_Array |                     Array |   100 | 1.329 μs | 0.0132 μs | 0.0123 μs |  0.46 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 | 1.515 μs | 0.0091 μs | 0.0085 μs |  0.52 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.513 μs | 0.0080 μs | 0.0071 μs |  0.52 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.638 μs | 0.0081 μs | 0.0067 μs |  0.57 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 3.192 μs | 0.0208 μs | 0.0184 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.264 μs | 0.0147 μs | 0.0138 μs |  0.71 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1.513 μs | 0.0082 μs | 0.0077 μs |  0.47 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 3.177 μs | 0.0116 μs | 0.0109 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.255 μs | 0.0174 μs | 0.0154 μs |  0.71 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1.611 μs | 0.0198 μs | 0.0175 μs |  0.51 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 3.194 μs | 0.0141 μs | 0.0125 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|               StructLinq_List_Value |                List_Value |   100 | 1.479 μs | 0.0083 μs | 0.0073 μs |  0.46 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 2.150 μs | 0.0131 μs | 0.0102 μs |  0.67 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7.507 μs | 0.0173 μs | 0.0153 μs |  1.00 | 2.0599 |     - |     - |   4,320 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4.560 μs | 0.0202 μs | 0.0169 μs |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 3.193 μs | 0.0142 μs | 0.0119 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.267 μs | 0.0097 μs | 0.0086 μs |  0.71 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.695 μs | 0.0076 μs | 0.0063 μs |  0.84 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 3.201 μs | 0.0086 μs | 0.0076 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 2.272 μs | 0.0070 μs | 0.0058 μs |  0.71 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 2.684 μs | 0.0058 μs | 0.0055 μs |  0.84 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 3.231 μs | 0.0276 μs | 0.0230 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 2.264 μs | 0.0130 μs | 0.0115 μs |  0.70 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1.961 μs | 0.0073 μs | 0.0064 μs |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7.527 μs | 0.0221 μs | 0.0196 μs |  1.00 | 2.0599 |     - |     - |   4,320 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5.132 μs | 0.0460 μs | 0.0408 μs |  0.68 | 0.0153 |     - |     - |      32 B |
