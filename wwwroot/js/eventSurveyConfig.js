const eventSurveyConfig = {
    "title": "Edit Event",
    "description": "Please provide event details",
    "logoPosition": "right",
    "pages": [
        {
            "name": "event",
            "elements": [
                {
                    "type": "text",
                    "name": "Title",
                    "title": "Title (shown in the event bar)",
                    "isRequired": true,
                    "defaultValue": "May event"
                },
                {
                    "type": "comment",
                    "name": "Description",
                    "title": "Description (shown in the event's Bubble/Tooltip)"
                },
                {
                    "type": "panel",
                    "name": "dates",
                    "elements": [
                        {
                            "type": "text",
                            "inputType": "datetime-local",
                            "name": "StartDate",
                            "title": "Start Date & Time",
                            "isRequired": true,
                            "defaultValue": "2025-05-10T00:00"
                        },
                        {
                            "type": "text",
                            "inputType": "datetime-local",
                            "name": "EndDate",
                            "title": "End Date & Time",
                            "isRequired": true,
                            "defaultValue": "2025-05-10T08:00"
                        }
                    ],
                    "title": "Event Date/Time"
                },
                {
                    "type": "dropdown",
                    "name": "AssignedTo",
                    "title": "Assign event to:",
                    "isRequired": true,
                    "placeholder": "Team member or assign in Timesheet",
                    "choices": [
                        "John Smith",
                        "Jane Doe",
                        "Alex Johnson",
                        "Team A",
                        "Team B"
                    ]
                }
            ]
        }
    ],
    "showQuestionNumbers": false,
    "completeText": "OK",
    "cancelText": "Cancel",
    "showPreviewBeforeComplete": "showAnsweredQuestions"
};