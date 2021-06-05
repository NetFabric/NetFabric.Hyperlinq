## ContainsBenchmarks

### Source
[ContainsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    38.54 ns | 0.188 ns | 0.167 ns |  1.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    30.81 ns | 0.105 ns | 0.093 ns |  0.80 |      - |     - |     - |         - |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    23.83 ns | 0.079 ns | 0.074 ns |  0.62 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   627.99 ns | 5.507 ns | 4.598 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   199.88 ns | 0.929 ns | 0.823 ns |  0.32 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    36.85 ns | 0.196 ns | 0.183 ns |  1.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    39.51 ns | 0.242 ns | 0.226 ns |  1.07 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    37.52 ns | 0.208 ns | 0.184 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |    39.57 ns | 0.125 ns | 0.104 ns |  1.05 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,616.30 ns | 3.258 ns | 2.888 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   942.80 ns | 2.209 ns | 2.066 ns |  0.58 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   632.57 ns | 3.394 ns | 3.174 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   687.02 ns | 6.790 ns | 5.670 ns |  1.09 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    36.59 ns | 0.167 ns | 0.148 ns |  1.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    38.74 ns | 0.180 ns | 0.150 ns |  1.06 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    37.41 ns | 0.140 ns | 0.131 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    40.01 ns | 0.271 ns | 0.226 ns |  1.07 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,628.33 ns | 3.355 ns | 2.975 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,742.85 ns | 7.018 ns | 6.221 ns |  1.07 | 0.0153 |     - |     - |      32 B |
