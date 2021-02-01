## FirstBenchmarks

### Source
[FirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/FirstBenchmarks.cs)

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
|                         Method |                Categories | Count |       Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |-----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |  21.426 ns | 0.0585 ns | 0.0547 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array |   100 |   4.999 ns | 0.0220 ns | 0.0195 ns |  0.23 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                     Array |   100 |   5.013 ns | 0.0061 ns | 0.0054 ns |  0.23 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |   6.534 ns | 0.0105 ns | 0.0093 ns |  0.30 |      - |     - |     - |         - |
|                                |                           |       |            |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  23.940 ns | 0.0419 ns | 0.0350 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  14.134 ns | 0.0313 ns | 0.0277 ns |  0.59 |      - |     - |     - |         - |
|                                |                           |       |            |           |           |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  25.161 ns | 0.0654 ns | 0.0611 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  15.751 ns | 0.0248 ns | 0.0220 ns |  0.63 |      - |     - |     - |         - |
|                                |                           |       |            |           |           |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  12.900 ns | 0.0202 ns | 0.0179 ns |  1.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value |   100 |   7.295 ns | 0.0195 ns | 0.0183 ns |  0.57 |      - |     - |     - |         - |
|                                |                           |       |            |           |           |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 115.584 ns | 0.2322 ns | 0.1939 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                                |                           |       |            |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  20.376 ns | 0.0777 ns | 0.0689 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  24.218 ns | 0.0607 ns | 0.0538 ns |  1.19 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |            |           |           |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  21.360 ns | 0.0450 ns | 0.0399 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  16.310 ns | 0.1366 ns | 0.1066 ns |  0.76 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |            |           |           |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  12.909 ns | 0.0265 ns | 0.0222 ns |  1.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference |   100 |   7.257 ns | 0.0133 ns | 0.0111 ns |  0.56 |      - |     - |     - |         - |
|                                |                           |       |            |           |           |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 111.250 ns | 0.1898 ns | 0.1776 ns |  1.00 | 0.0191 |     - |     - |      40 B |
