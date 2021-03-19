## SingleBenchmarks

### Source
[SingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SingleBenchmarks.cs)

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
|                         Method |                Categories |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array | 11.635 ns | 0.0684 ns | 0.0640 ns | 11.627 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array | 13.992 ns | 0.0369 ns | 0.0346 ns | 13.991 ns |  1.20 |    0.01 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value | 22.812 ns | 0.1626 ns | 0.1357 ns | 22.762 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value | 16.591 ns | 0.0190 ns | 0.0148 ns | 16.588 ns |  0.73 |    0.00 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value | 24.000 ns | 0.0923 ns | 0.0771 ns | 24.008 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value | 20.092 ns | 0.4312 ns | 0.9283 ns | 19.611 ns |  0.83 |    0.04 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |  7.458 ns | 0.0386 ns | 0.0342 ns |  7.458 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value | 15.178 ns | 0.0638 ns | 0.0533 ns | 15.181 ns |  2.04 |    0.01 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value | 80.227 ns | 0.2933 ns | 0.2449 ns | 80.195 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference | 23.091 ns | 0.1006 ns | 0.0892 ns | 23.088 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference | 20.565 ns | 0.2968 ns | 0.3048 ns | 20.477 ns |  0.89 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference | 23.872 ns | 0.1125 ns | 0.1052 ns | 23.871 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference | 19.679 ns | 0.1339 ns | 0.1187 ns | 19.635 ns |  0.82 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |  7.714 ns | 0.1763 ns | 0.3223 ns |  7.603 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference | 15.060 ns | 0.0598 ns | 0.0530 ns | 15.045 ns |  1.93 |    0.11 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference | 81.415 ns | 1.6193 ns | 3.4857 ns | 79.958 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
