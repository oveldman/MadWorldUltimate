#Install on MacOS
brew install certbot

#Update new certifate for the website
certbot certonly --manual --preferred-challenges dns  -d api.mad-world.nl

#Convert to one cert
openssl pkcs12 -export -out site.pfx -inkey privkey.pem -in cert.pem -certfile fullchain.pem