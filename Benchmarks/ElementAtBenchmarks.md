## ElementAtBenchmarks

### Source
[ElementAtBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ElementAtBenchmarks.cs)

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
|                         Method |                Categories | Count |         Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |-------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |    23.360 ns | 0.0504 ns | 0.0447 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array |   100 |     5.306 ns | 0.0090 ns | 0.0084 ns |  0.23 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                     Array |   100 |     5.032 ns | 0.0040 ns | 0.0031 ns |  0.22 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |     6.595 ns | 0.0121 ns | 0.0113 ns |  0.28 |      - |     - |     - |         - |
|                                |                           |       |              |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |   359.232 ns | 0.5723 ns | 0.4779 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   137.595 ns | 0.2246 ns | 0.1991 ns |  0.38 |      - |     - |     - |         - |
|                                |                           |       |              |           |           |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |   317.957 ns | 5.4123 ns | 4.5195 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |   143.821 ns | 0.2611 ns | 0.2443 ns |  0.45 |      - |     - |     - |         - |
|                                |                           |       |              |           |           |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |    10.390 ns | 0.0256 ns | 0.0227 ns |  1.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value |   100 |     6.672 ns | 0.0243 ns | 0.0215 ns |  0.64 |      - |     - |     - |         - |
|                                |                           |       |              |           |           |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,078.866 ns | 4.3966 ns | 4.1125 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                                |                           |       |              |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   231.469 ns | 0.3659 ns | 0.3243 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   241.359 ns | 1.1134 ns | 1.0415 ns |  1.04 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |              |           |           |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |   231.936 ns | 0.3911 ns | 0.3659 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   255.067 ns | 0.8164 ns | 0.7237 ns |  1.10 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |              |           |           |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |    10.386 ns | 0.0318 ns | 0.0282 ns |  1.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference |   100 |     6.670 ns | 0.0148 ns | 0.0132 ns |  0.64 |      - |     - |     - |         - |
|                                |                           |       |              |           |           |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,945.874 ns | 4.9947 ns | 4.4276 ns |  1.00 | 0.0191 |     - |     - |      40 B |
