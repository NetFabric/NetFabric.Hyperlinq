## SelectManyBenchmarks

### Source
[SelectManyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectManyBenchmarks.cs)

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
|                         Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |  2.825 μs | 0.0094 μs | 0.0084 μs |  1.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq_Array |                     Array |   100 |  1.227 μs | 0.0019 μs | 0.0016 μs |  0.43 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |  1.415 μs | 0.0230 μs | 0.0215 μs |  0.50 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  2.925 μs | 0.0093 μs | 0.0077 μs |  1.00 | 1.9569 |     - |     - |   4,096 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  3.394 μs | 0.0151 μs | 0.0141 μs |  1.16 | 2.3575 |     - |     - |   4,936 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  2.993 μs | 0.0306 μs | 0.0255 μs |  1.00 | 1.9569 |     - |     - |   4,096 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  3.451 μs | 0.0081 μs | 0.0067 μs |  1.15 | 2.3575 |     - |     - |   4,936 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  2.919 μs | 0.0096 μs | 0.0080 μs |  1.00 | 1.9569 |     - |     - |   4,096 B |
|           Hyperlinq_List_Value |                List_Value |   100 |  3.660 μs | 0.0242 μs | 0.0214 μs |  1.25 | 2.3537 |     - |     - |   4,928 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 12.341 μs | 0.0542 μs | 0.0480 μs |  1.00 | 2.3346 |     - |     - |   4,904 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  2.992 μs | 0.0233 μs | 0.0218 μs |  1.00 | 1.9569 |     - |     - |   4,096 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.384 μs | 0.0112 μs | 0.0099 μs |  1.13 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  2.966 μs | 0.0183 μs | 0.0171 μs |  1.00 | 1.9569 |     - |     - |   4,096 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  3.468 μs | 0.0193 μs | 0.0171 μs |  1.17 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  2.976 μs | 0.0175 μs | 0.0155 μs |  1.00 | 1.9569 |     - |     - |   4,096 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |  3.618 μs | 0.0194 μs | 0.0162 μs |  1.22 | 2.3537 |     - |     - |   4,928 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 12.289 μs | 0.0295 μs | 0.0247 μs |  1.00 | 2.3346 |     - |     - |   4,904 B |
