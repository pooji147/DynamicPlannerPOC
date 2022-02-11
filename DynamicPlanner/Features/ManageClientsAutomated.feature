Feature: ManageClients
	As a financial adviser, I would like a way of managing my clients. I would like to see a list of my clients; and see their full name and date of birth. 
	I would like to be able to create a client manually, edit a client once it has been made, and delete a client.

@mangeClients
Scenario: View list of clients
	Given the open manage clients 
	When the add new client by entering 'Poojitha', 'Ravipati', and '29/01/1987'
	Then the user is able to create a client 'Poojitha' record sucessfully
	And delete client 'Poojitha'
	Then user able to delete Successfully
