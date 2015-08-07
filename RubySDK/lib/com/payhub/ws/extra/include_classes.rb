Dir["../lib/com/payhub/ws/util/*.rb"].each {|file| require file }
Dir["../lib/com/payhub/ws/model/*.rb"].each {|file| require file }
Dir["../lib/com/payhub/ws/api/*.rb"].each {|file| require file }

Dir["../lib/com/payhub/ws/util/*.rb"].each {|file| puts file.to_s }
Dir["../lib/com/payhub/ws/model/*.rb"].each {|file| puts file.to_s}
Dir["../lib/com/payhub/ws/api/*.rb"].each {|file| puts file.to_s}
Dir["../lib/com/payhub/ws/extra/*.rb"].each {|file| puts file.to_s}