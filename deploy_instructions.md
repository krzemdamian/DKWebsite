# Instructions

## Nginx configuration
Nginx is configured to use HTTPS.
Before first run lets encrypt certificate must be created.
It is done by init-letsencrypt.sh shell script.
When certifcate is obtained (certificate folder is not empty) nginx will be able to work properly.

## Docker networks
Before deploy two docker networks must be created manually.
Networks: frontend and backed. Both have to be configured as *bridge* driver networks.