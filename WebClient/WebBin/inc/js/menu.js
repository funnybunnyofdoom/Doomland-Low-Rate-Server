/* menu Saved Discussions */
function SavedDiscussions(data){
	var html = '';
	if(data.length){
		var classId = '';
		if(currentPage == 'discussion'){
			classId = getURLParameter('classId');
		}
		for(i in data){
			if(classId == data[i].Guid){
				html+= "<li class='menu-highlight'><a href='/discussion.html?classId="+data[i].Guid+"' id='"+data[i].Guid+"'>"+data[i].Title+"</a></li>";
			}else{
				html+= "<li><a href='/discussion.html?classId="+data[i].Guid+"' id='"+data[i].Guid+"'>"+data[i].Title+"</a></li>";
			}
		}
		$('#save-discussion > a').html("Saved Discussions <span class='caret'></span>");
		$('#menu-save-discussion').append(html);
	}else{
		$('#save-discussion > a').html("No Saved Discussions").addClass('menu-no-link');
	}
}

/* menu Run For Office */
function RunForOfficeMenu(data){
	// setTimeout(function(){
		$('a#add-self').hide();
		$('#add-self').html('update speech');
		$('#add-self').attr('data-action', 'update');
		$('#election-propose-button:not(.eco-button)').html('Update Speech').attr('data-action', 'update');
		
	// },500)
}


/* menu Previous Elections */
function PreviousElectionsMenu(data){
	if(data.length == 0){
		$('#previous-elections-wrapper').hide();
		$('li#previous-elections > a').html("No Previous Elections");
		$('li#previous-elections > a').addClass('menu-no-link');
		return false;
	}else{

		//adding previous elections
		$('li#previous-elections > a').html("Previous Elections <span class='caret'></span>");
		$('.previous-elections-wrapper').empty();

		//sorting in order to show the most recent election first
		data.sort( function(a,b){
			return a.TimeEndAgo - b.TimeEndAgo;
		})

		for(var i = 0; i < data.length; i++)
		{
			var highlight = "";

			if(data[i].Guid == getURLParameter("election")){
				highlight = "menu-highlight";
			}
			var item = $("<li class='"+highlight+"'><a href='/elections.html?election="+data[i].Guid+"' class='previous-election' data-guid = '"+ data[i].Guid +"'>  <b>Winner: </b>"+ ( (data[i].Results.Winner != "" ? data[i].Results.Winner : "No Winner" ) ) +"<br><small> <b> Ended: </b> "+ ConvertSeconds(data[i].TimeEndAgo) +" ago </small> </a></li>");
			$('.previous-elections-wrapper').append(item);
		}
	}
}


/* menu Active and Proposed Laws*/
function ActiveProposedLawsMenu(data){
	//Active Laws
	var activeLaws = false;
	var lawsActiveHtml = "";

	//Proposed Laws
	var proposedLaws = false;
	var proposedLawsHtml = "";

	$.each(data,function(index,words){
		var highlight = "";
		if(words['Guid'] == getURLParameter("lawid")){
			highlight = "menu-highlight";
		}

		if(words['InEffect'] == true) {
			activeLaws = true;
			if(words['Period'] < 2) {day = 'day';} else {day = 'days';};
			lawsActiveHtml += "<li class='"+highlight+"'><a href='/laws.html?lawid="+words['Guid']+"' id='"+words['Guid']+"'><span class='laws-title'>"+words['Title']+"</span><br/>";
			//lawsActiveHtml += "Each player may not "+words['Action']+" more than "+words['Value']+" "+words['Target']+" per day.<br/>";
			lawsActiveHtml += "</a></li>\n";
		}

		if(words['InEffect'] == false) {
			proposedLaws = true;
			if(words['Period'] < 2) {day = 'day';} else {day = 'days';};
			proposedLawsHtml += "<li class='"+highlight+"'><a href='/laws.html?lawid="+words['Guid']+"' id='"+words['Guid']+"' href='/index.html?lawid="+words['Guid']+"'><span class='laws-title'>"+words['Title']+"</span><br/>";
			//proposedLawsHtml += "Each player may not "+words['Action']+" more than "+words['Value']+" "+words['Target']+" per day.<br/>";
			proposedLawsHtml += "<span class='laws-menu-voting'><span class='laws-menu-voting-yes'>"+words['VotesYes']+" YES</span> &nbsp; <span class='laws-menu-voting-no'>"+words['VotesNo']+" NO</span></span><br/>";
			proposedLawsHtml += "</a></li>\n";
		}
	});

	//showing the message if there's no active or proposed laws
	if(!proposedLaws){
		$('#proposed-laws > a').html("No Proposed Laws")
		$('#proposed-laws > a').addClass('menu-no-link');
	}else{
		$('#proposed-laws > a').html("Proposed Laws <span class='caret'></span>");
		$('#proposed-laws ul li').remove();
		$('#proposed-laws ul').append(proposedLawsHtml);
	}

	if(!activeLaws){
		$('#active-laws > a').html("No Active Laws")
		$('#active-laws > a').addClass('menu-no-link');
	}else{
		$('#active-laws > a').html("Active Laws <span class='caret'></span>");
		$('#active-laws ul li').remove();
		$('#active-laws ul').append(lawsActiveHtml);
	}
}
