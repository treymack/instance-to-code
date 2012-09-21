require 'albacore'

desc "build the code"
msbuild :build do |msb|
  msb.properties = { :configuration => :Debug }
  msb.targets = [ :Clean, :Build ]
  msb.solution = "Instance.ToCode.sln"
end

desc "run the tests"
nunit :test => [ :build ] do |nunit|
	nunit.command = "packages/NUnit.Runners.2.6.1/tools/nunit-console-x86.exe"
	nunit.assemblies "src/TheProject/bin/Debug/TheProject.dll"
end
