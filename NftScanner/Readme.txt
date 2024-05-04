Transaction Nft Scanner
Motivation

One of the reasons why decentralized apps are great for users is that anyone can monitor what's happening internally in the app. Let's say that we use this to our advantage. We want to create an application that can display NFT images of all NFTs involved in a given transaction.

Your Task

Create a console application using .NET, which takes a transaction hash as an input parameter and downloads all NFT images associated with that transaction.


- To gather the necessary information about the transaction and related assets, you can use the Blockfrost API (https://blockfrost.io). If you want to use blockfrost API without registration, you can use our apiKey with each of your request in header:


    project_id: mainnetRUrPjKhpsagz4aKOCbvfTPHsF0SmwhLc

To safe your time with API documentation, we will hint that you will need to use two API endpoints to retrieve the necessary information for this task:

https://blockfrost.dev/api/transaction-utx-os
https://blockfrost.dev/api/specific-asset

These two endpoints will help you retrieve information about the inputs and outputs of a transaction and information about the asset, especially asset onchain metadata, where you can find the IPFS image hash.

Note: You can use blockfrost-dotnet SDK https://blockfrost.dev/sdks-dotnet


- To retrieve the images after obtaining the IPFS hash, you may use an IPFS gateway provider like Cloudflare IPFS (https://cloudflare-ipfs.com). Images can be accessed directly via URL in this form:


    https://cloudflare-ipfs.com/ipfs/{ipfsHash}

For example, if Jammie's NFT IPFS hash is ‘Qmc8tAGUPTRfXVWv9aKyNf9m6nCcAj3BR8KcYDXM7trVtd’, you can discover how Jammie looks like via this link:

https://cloudflare-ipfs.com/ipfs/Qmc8tAGUPTRfXVWv9aKyNf9m6nCcAj3BR8KcYDXM7trVtd


- You have to detect all NFTs related to input and output of the transaction. For simplicity, let’s assume that asset is NFT if it has a Quantity of 1 and its Unit is not "lovelace". 


- Your project should include a folder named “Transactions”. For each transaction scanned, create a folder named after the transaction hash that was scanned. Inside this folder, download images of all NFTs included in the transaction. Each image should be named after the NFT it displays.


- Here are examples of transaction hashes wich you can use to check whether your app is working correctly:

2ea275d07c1f52a1936fb22999c13da4729d68bbf7ddaf978fbb2255aa71a225
f6de1ed8182386ae9e9eb849bbf4ff547948cbce1f2286465221ba05de3a3e1b


- We don't expect you to write any tests. But you should definitely make your code clean and concise.


- When you are done with coding, publish your code to a public github repo