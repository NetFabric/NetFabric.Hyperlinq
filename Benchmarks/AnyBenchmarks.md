## AnyBenchmarks

### Source
[AnyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  8.7865 ns | 0.0358 ns | 0.0318 ns | 1.000 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  0.0000 ns | 0.0000 ns | 0.0000 ns | 0.000 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |  0.5244 ns | 0.0186 ns | 0.0165 ns | 0.060 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |  0.2542 ns | 0.0066 ns | 0.0059 ns | 0.029 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 20.5024 ns | 0.1154 ns | 0.1023 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 12.4688 ns | 0.0330 ns | 0.0293 ns |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  4.8538 ns | 0.0168 ns | 0.0140 ns |  1.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  4.6245 ns | 0.0119 ns | 0.0105 ns |  0.95 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  5.5336 ns | 0.0157 ns | 0.0139 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  1.7812 ns | 0.0093 ns | 0.0087 ns |  0.32 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 66.4073 ns | 0.3688 ns | 0.3080 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 60.3088 ns | 0.1136 ns | 0.1007 ns |  0.91 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 18.3779 ns | 0.0678 ns | 0.0634 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 10.5758 ns | 0.0991 ns | 0.0828 ns |  0.58 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  4.9100 ns | 0.0256 ns | 0.0239 ns |  1.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  1.7918 ns | 0.0128 ns | 0.0107 ns |  0.36 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  5.5565 ns | 0.0178 ns | 0.0158 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  1.8166 ns | 0.0157 ns | 0.0139 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 62.4382 ns | 0.1938 ns | 0.1618 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 62.1935 ns | 0.1632 ns | 0.1363 ns |  1.00 | 0.0191 |     - |     - |      40 B |
