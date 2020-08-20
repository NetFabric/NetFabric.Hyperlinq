## AnyBenchmarks

### Source
[AnyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
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
|                              Method |                Categories | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  9.4461 ns | 0.0428 ns | 0.0357 ns | 1.000 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  0.0000 ns | 0.0000 ns | 0.0000 ns | 0.000 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |  0.2930 ns | 0.0208 ns | 0.0184 ns | 0.031 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |  0.2566 ns | 0.0081 ns | 0.0076 ns | 0.027 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 19.2178 ns | 0.1320 ns | 0.1235 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  6.4250 ns | 0.0440 ns | 0.0412 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  4.4953 ns | 0.0643 ns | 0.0601 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  5.8704 ns | 0.0564 ns | 0.0528 ns |  1.31 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  5.2400 ns | 0.0659 ns | 0.0616 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  2.6538 ns | 0.0302 ns | 0.0282 ns |  0.51 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 67.0313 ns | 0.4644 ns | 0.4344 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 74.5255 ns | 0.2590 ns | 0.2423 ns |  1.11 |    0.01 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 17.7721 ns | 0.0972 ns | 0.0812 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 10.9049 ns | 0.1464 ns | 0.1369 ns |  0.61 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  4.4743 ns | 0.0552 ns | 0.0489 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  2.8460 ns | 0.0207 ns | 0.0183 ns |  0.64 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  5.2417 ns | 0.0680 ns | 0.0636 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  2.6751 ns | 0.0269 ns | 0.0239 ns |  0.51 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 63.5088 ns | 0.9177 ns | 0.7165 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 71.7939 ns | 0.5301 ns | 0.4958 ns |  1.13 |    0.01 | 0.0305 |     - |     - |      64 B |
