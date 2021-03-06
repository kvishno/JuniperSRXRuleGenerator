# JuniperSRXRuleGenerator

Automates writing security policies in bulk for SRX devices.

CSV format (Comma-delimited):
```
FromZone,ToZone,Source,Destination,RuleName,Application
Untrust,DMZ,any,WebServer01,SomeRuleName,junos-http
```
Output:
```
set security policies from-zone Untrust to-zone DMZ policy SomeRuleName match source-address any
set security policies from-zone Untrust to-zone DMZ policy SomeRuleName match destination-address WebServer01
set security policies from-zone Untrust to-zone DMZ policy SomeRuleName match application junos-http
set security policies from-zone Untrust to-zone DMZ policy SomeRuleName then permit
set security policies from-zone Untrust to-zone DMZ policy SomeRuleName then log session-init session-close
```

The following columns can take multiple values seperated by space
* Source
* Destination
* Application

Example:  
```
FromZone,ToZone,Source,Destination,RuleName,Application
DMZ,Server,Web01 Web02 LB01,grpDCXX grpDockerXX,SomeRuleName,junos-dns-udp junos-https junos-ldap
```
Output:
```
set security policies from-zone DMZ to-zone Server policy SomeRuleName match source-address Web01
set security policies from-zone DMZ to-zone Server policy SomeRuleName match source-address Web02
set security policies from-zone DMZ to-zone Server policy SomeRuleName match source-address LB01
set security policies from-zone DMZ to-zone Server policy SomeRuleName match destination-address grpDCXX
set security policies from-zone DMZ to-zone Server policy SomeRuleName match destination-address grpDockerXX
set security policies from-zone DMZ to-zone Server policy SomeRuleName match application junos-dns-udp
set security policies from-zone DMZ to-zone Server policy SomeRuleName match application junos-https
set security policies from-zone DMZ to-zone Server policy SomeRuleName match application junos-ldap
set security policies from-zone DMZ to-zone Server policy SomeRuleName then permit
set security policies from-zone DMZ to-zone Server policy SomeRuleName then log session-init session-close
```

Another example can be found here [rules.csv](https://github.com/kvishno/JuniperSRXRuleGenerator/blob/master/JuniperSRXRuleGenerator/rules.csv) - [output](https://github.com/kvishno/JuniperSRXRuleGenerator/blob/master/JuniperSRXRuleGenerator/Output.txt)

## How to run
Build from source (.NET Core 3.1)

```
## Default loads rules.csv in current directory
JuniperSRXRuleGenerator.exe
or
JuniperSRXRuleGenerator.exe "C:\path\to\csv\your_file.csv"
```
