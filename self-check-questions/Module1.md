## What are the cons and pros of the Monolith architectural style? 
Pros of Monolithic Architecture:
1. Simplicity: A monolithic application is developed in one codebase, which makes it easier to develop, test, and deploy. You don’t have to deal with the complexities of inter-process communication that you would encounter in microservices.
2. Performance: Since all the components run within the same process, calling functions or methods directly is faster than inter-process communication.
3. Consistency: It’s easier to manage transactions and maintain data consistency in a monolithic application because you’re dealing with a single database.
4. Operational Overhead: Monolithic applications are simpler to deploy and run because they’re self-contained. You don’t need to manage and monitor multiple services like you would in a microservices architecture.
Cons of Monolithic Architecture:
1. Scalability: Scaling a monolithic application can be challenging. You might have to scale the entire application even if only one part of it has a high load.
2. Development Speed: As the application grows, the codebase becomes larger and more complex, making it harder to understand and update.
3. Technology Stack: In a monolithic application, you’re generally locked into one technology stack, which can limit your ability to use the best tools for specific tasks.
4. Fault Isolation: If there’s a bug or an issue in one part of the application, it can bring down the entire system. This is less likely in a microservices architecture where services are isolated.
5. Deployment Risk: Since the entire application is deployed at once, there’s a risk that a small change could impact the entire system.

## What are the cons and pros of the Microservices architectural style?
Microservices Architecture refers to a method of developing software systems that are made up of independently deployable, modular services. Each service runs a unique process and communicates through a well-defined, lightweight mechanism (often HTTP based) to serve a business goal.
Pros of Microservices Architecture:
1. Scalability: In a microservices architecture, each service can be scaled independently based on demand. This is particularly useful if different services have different resource requirements.
2. Development Speed: Microservices can be developed independently by small teams that are organized around the business capabilities they are responsible for. This can lead to increased productivity and speed of development.
3. Technology Diversity: With microservices, you can use the best language, framework, or technology stack for the particular service based on its requirements.
4. Fault Isolation: A failure in one service does not directly impact other services. This is a significant advantage over monolithic applications where a failure in one component can bring down the entire application.
5. Deployment and Updates: Individual microservices can be updated or deployed independently without affecting the entire application. This allows for more frequent updates and reduces the risk associated with deployment.
Cons of Microservices Architecture:
1. Complexity: Microservices introduce complexity because developers must mitigate the issues of distributed systems. This includes network latency, message formats, load balancing, data consistency, and fault tolerance.
2. Data Consistency: Maintaining data consistency across services is challenging as each service has its own database.
3. Inter-Service Communication: As the number of services increases, managing the communication between them becomes complex.
4. Operational Overhead: Microservices require sophisticated DevOps skills and tools for managing services, databases, and their interactions.
5. Testing: Testing microservices-based applications can be complex due to the need to test individual components as well as the interactions between them.

## What is the difference between SOA and Microservices?
Service-Oriented Architecture (SOA) and Microservices are both architectural styles that design software as a collection of services. However, they differ in their focus, granularity, and how they are implemented and used in practice.
SOA is an architectural style that aims to provide business functionality as a set of loosely coupled services. In SOA, services are built on the basis of the business functionality each service will provide. These services communicate with each other, often using a communication protocol over a network.
Microservices, on the other hand, is an architectural style that structures an application as a collection of small autonomous services, modeled around a business domain.
Here are some key differences:
1. Granularity: SOA services are coarse-grained business components, while microservices are finer-grained.
2. Data Storage: In SOA, services often share a common database. In contrast, each microservice in a microservices architecture usually has its own dedicated database.
3. Communication: SOA services often communicate through an Enterprise Service Bus (ESB), which can add additional complexity and reduce performance. Microservices usually communicate through simpler methods like RESTful APIs or messaging queues.
4. Deployment: SOA services are often deployed together as a monolith, while microservices are deployed independently.
5. Focus: SOA is more business-focused, aiming to expose business functionality as services. Microservices are more focused on decoupling, aiming to create small services that can be developed and deployed independently.
6. Size of Services: Microservices are typically smaller in size compared to SOA services, which can be relatively large.

## What does hybrid architectural style mean? Think of your current and previous projects and try to describe which architectural styles they most likely followed.
A Hybrid Architectural Style is a type of software architecture that combines two or more architectural styles to create a new system. The goal of a hybrid architecture is to leverage the strengths and mitigate the weaknesses of the combined architectural styles.
For example, a system might use a monolithic architecture for its core services that require high performance and strong consistency, and use a microservices architecture for other services that need to be highly scalable and independently deployable. This combination would be a hybrid of monolithic and microservices architectures.
Here are some key points about Hybrid Architectural Style:
1. Flexibility: Hybrid architectures provide the flexibility to choose the best architectural style for each part of the system based on its requirements.
2. Performance: By combining architectural styles, a hybrid architecture can optimize performance. For example, a system might use a monolithic architecture for high-performance components and a microservices architecture for components that need to scale independently.
3. Scalability: Hybrid architectures can provide better scalability than a single architectural style by allowing different parts of the system to scale independently.
4. Complexity: Implementing a hybrid architecture can be more complex than implementing a single architectural style because it requires managing and integrating multiple architectural styles.
Experience from the current project: I used to think that our current project follows the monolithic architectural style. However, after studying the first module, I see it as a hybrid architecture. There are applications that are monoliths, but if we take the solution as a whole, it leverages SOA, Monolithic, and Microkernel architectures. 

## Name several examples of the distributed architectures. What do ACID and BASE terms mean.
Microservices, P2P, SOA, N-Tier, Serverless are several examples of distributed architectures.
ACID is an acronym for Atomicity, Consistency, Isolation, and Durability. These are a set of properties that guarantee reliable processing of database transactions.
- Atomicity: This property ensures that a transaction is treated as a single, indivisible unit, which either succeeds completely, or fails completely.
- Consistency: This ensures that a transaction brings a database from one valid state to another.
- Isolation: This property ensures that concurrent execution of transactions leaves the database in the same state that would have been obtained if the transactions were executed sequentially.
- Durability: This property ensures that once a transaction has been committed, it will remain committed even in the case of a system failure.
BASE is an acronym for Basically Available, Soft state, Eventually consistent. It is a set of properties that describe systems where data consistency is relaxed.
- Basically Available: This property indicates that the system does guarantee availability.
- Soft State: The state of the system could change over time, even without input due to the eventual consistency model.
- Eventually Consistent: This property suggests that the system will become consistent over time, given that the system doesn’t receive input during that time.
In summary, ACID and BASE represent two different approaches to handling transactions in a distributed system. ACID prioritizes consistency, making it a good fit for applications where consistency of data is critical. BASE, on the other hand, prioritizes availability and partition tolerance, making it a good fit for systems where data can be inconsistent for a period of time.

## Name several use cases where Serverless architecture would be beneficial.
1. Real-Time File Processing: Serverless is great for real-time file processing. For example, you can use it to automatically create thumbnails when an image is uploaded to a cloud storage service.
2. Data Transformation: Serverless functions can be triggered to transform data as it’s inserted into a database. This is useful for tasks like data cleaning and aggregation.
3. Microservices: Serverless is a good fit for microservices because it allows each function to scale independently. This can make your application more resilient and easier to manage.
4. Real-Time Analytics: Serverless can be used to process and analyze data in real-time. For example, you could use it to track clicks on a website and update a dashboard in real time.
5. Scheduled Tasks: Serverless is great for scheduled tasks or cron jobs. For example, you could use it to send out a daily email newsletter at a specific time.
6. IoT Services: Serverless is a good fit for IoT services because it can handle the high volume of events generated by IoT devices.