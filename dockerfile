FROM postgres:latest


ENV POSTGRES_USER=admin
ENV POSTGRES_PASSWORD=admin

EXPOSE 54322

# CMD ["postgres"]
