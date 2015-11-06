
			var currentDragRow, movedRow = null;
			var isMouseOver = 0;
			var radGridOver = "";
			var isDragDropEnabled = false;

			function drover(dr)
			{
				radGridOver = "DeleteRow";
				dr.style.border = "solid 2px #666";
				dr.style.padding = "1px";
			};
			function drout(dr)
			{
				radGridOver = "";
				dr.style.border = "solid 1px #666";
				dr.style.padding = "2px";
			};
			function enabledragdrop()
			{
				//this is to prevent errors when you start dragging items 
				//before the page is completely loaded
				isDragDropEnabled = true;
			};
			function RowCreated(row)
			{
				var mouseDownHandler = function(e)
				{
					if (!isDragDropEnabled)
						return;
					if (!e)
						var e = window.event;
					if (!currentDragRow)
					{
						currentDragRow = document.createElement("DIV");
						currentDragRow.innerHTML = "<table class='RadGrid_Grid' width='100%'><tbody><tr>"+row.Control.innerHTML+"</tr></tbody><table>";
						document.body.appendChild(currentDragRow);
						currentDragRow.style.position = "absolute";
						currentDragRow.style.display = "none";
						movedRow = row;
					}
					
					ClearDocumentEvents();				
				};
				var mouseUpHandler = function(e)
				{
					if (!e)
						var e = window.event;
					if (currentDragRow)
					{
						if (movedRow && currentDragRow.style.display != "none")
						{
							movedRow.Owner.SelectRow(movedRow.Control, true);
							var PostBackString = new String();
							PostBackString = "__doPostBack('RowMoved','Args')";
							PostBackString = PostBackString.replace("Args",movedRow.Owner.Owner.ID+","+movedRow.Index+","+radGridOver); 
							if ("" != radGridOver && radGridOver != movedRow.Owner.Owner.ID)
								eval(PostBackString );
						}
						document.body.removeChild(currentDragRow);
						currentDragRow = null;
						movedRow = null;
					}
					RestoreDocumentEvents();
				};
				var mouseMoveHandler = function(e)
				{
					if (!e)
						var e = window.event;
					if (currentDragRow)
					{
						if (currentDragRow.style.display = "none")
						{
							currentDragRow.style.display = "block";
							currentDragRow.style.height = "24px";
							currentDragRow.style.width = "45%";
							//currentDragRow.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=1,opacity=80,finishOpacity=100,startX=100,finishX=100,startY=100,finishY=100)";
							//currentDragRow.style.MozOpacity = ".80";
						}
						currentDragRow.style.top =  e.clientY + 
												document.documentElement.scrollTop + 
												document.body.scrollTop + 3 + "px";

						currentDragRow.style.left = e.clientX + 
												document.documentElement.scrollLeft + 
												document.body.scrollLeft + 3 + "px";
					}
					
				};
				var mouseOverHandler = function(e)
				{
					if (!e)
						var e = window.event;
					var parentEl = e.srcElement;
					while (parentEl && parentEl.className != "RadGrid_Grid" && parentEl.id != "DeleteRow")
					{
					parentEl = parentEl.parentElement;
					}
					if (parentEl)
						radGridOver = parentEl.id;

					isMouseOver++;
				};
				var mouseOutHandler = function(e)
				{
					if (!e)
						var e = window.event;
					isMouseOver--;
					if (0 == isMouseOver)
					{

					}
				};
				if (row.ItemType == "Item" || row.ItemType == "AlternatingItem")
				{
					if (row.Control.attachEvent)
					{
						row.Control.attachEvent("onmousedown", mouseDownHandler);
						document.body.attachEvent("onmousemove", mouseMoveHandler);
					}
					if (row.Control.addEventListener)
					{
						row.Control.addEventListener("mousedown", mouseDownHandler, true);
						document.body.addEventListener("mousemove", mouseMoveHandler, true);
					}
				}
				if (row.Control.attachEvent)
				{
					document.body.attachEvent("onmouseup", mouseUpHandler);
					row.Owner.Owner.Control.attachEvent("onmouseover", mouseOverHandler);
					row.Owner.Owner.Control.attachEvent("onmouseout", mouseOutHandler);
				}
				if (row.Control.addEventListener)
				{
					document.body.addEventListener("mouseup", mouseUpHandler, true);
					row.Owner.Owner.Control.attachEvent("mouseover", mouseOverHandler, true);
					row.Owner.Owner.Control.attachEvent("mouseoout", mouseOutHandler, true);
				}
			};
			function ClearDocumentEvents()
			{
				if (document.onmousedown != this.mouseDownHandler)
				{
					this.documentOnMouseDown = document.onmousedown;
				}

				if (document.onselectstart != this.selectStartHandler)
				{
					this.documentOnSelectStart = document.onselectstart;
				}

				this.mouseDownHandler = function(e){return false;};
				this.selectStartHandler = function(){return false;};

				document.onmousedown = this.mouseDownHandler;
				document.onselectstart = this.selectStartHandler;

			};
			function RestoreDocumentEvents()
			{
				if ((typeof(this.documentOnMouseDown) == "function") &&
					(document.onmousedown != this.mouseDownHandler))
				{
					document.onmousedown = this.documentOnMouseDown;
				}
				else
				{
					document.onmousedown = "";
				}
				
				if ((typeof(this.documentOnSelectStart) == "function") &&
					(document.onselectstart != this.selectStartHandler))
				{
					document.onselectstart = this.documentOnSelectStart;
				}
				else
				{
					document.onselectstart = "";
				}
			};