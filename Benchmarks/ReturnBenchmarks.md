## ReturnBenchmarks

### Source
[ReturnBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ReturnBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.6.20305.6
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.3](https://www.nuget.org/packages/StructLinq/0.19.3)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G2021) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                 Method |   Categories |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------------- |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|            Linq_Return |       Return | 37.071 ns | 0.3791 ns | 0.3165 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|       Hyperlinq_Return |       Return |  9.925 ns | 0.0790 ns | 0.0660 ns |  0.27 |      - |     - |     - |         - |
|                        |              |           |           |           |       |        |       |       |           |
|      Linq_Return_Async | Return_Async | 86.999 ns | 1.4216 ns | 1.2602 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Return_Async | Return_Async | 54.932 ns | 0.5234 ns | 0.4640 ns |  0.63 |      - |     - |     - |         - |
