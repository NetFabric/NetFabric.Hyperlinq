## LinkedListBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Categories=All  

```
|        Method | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|      Linq_All | 10000 | 37.572 ns | 0.3148 ns | 0.2791 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_All | 10000 | 17.174 ns | 0.0854 ns | 0.0799 ns |  0.46 |      - |     - |     - |         - |
|    Custom_All | 10000 |  5.835 ns | 0.1210 ns | 0.1010 ns |  0.16 |      - |     - |     - |         - |
