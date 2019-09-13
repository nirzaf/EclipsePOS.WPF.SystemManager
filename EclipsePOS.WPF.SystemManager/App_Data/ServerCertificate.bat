makecert -r -pe -n "CN=CompanyXYZ Server" -b 01/01/2007 -e 01/01/2010 -sky exchange Server.cer -sv Server.pvk
pvk2pfx.exe -pvk Server.pvk -spc Server.cer -pfx Server.pfx
