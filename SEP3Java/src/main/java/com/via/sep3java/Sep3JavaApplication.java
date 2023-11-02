package com.via.sep3java;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@SpringBootApplication
@EnableJpaRepositories("com.via.sep3java.repository")
@EntityScan("com.via.sep3java.entity")
public class Sep3JavaApplication
{

	public static void main(String[] args) {
		SpringApplication.run(Sep3JavaApplication.class, args);
	}
}